import { Injectable, UnauthorizedException } from '@nestjs/common';
import { PassportStrategy } from '@nestjs/passport';
import { Strategy } from 'passport-local';
//
import { AuthService } from '@/api/auth/auth.service';

@Injectable()
export class LocalStrategy extends PassportStrategy(Strategy) {
  constructor(private authService: AuthService) {
    super({ usernameField: 'email', passReqToCallback: true });
  }

  async validate(
    req: any,
    username: string,
    password: string,
  ): Promise<any> {
    const user = await this.authService.login({
      device: req.body?.device,
      email: username,
      password,
    });
    if (!user) {
      throw new UnauthorizedException();
    }
    return user;
  }
}
