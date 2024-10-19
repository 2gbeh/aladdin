import { Controller, Post, Get, UseGuards, Request } from '@nestjs/common';
import { ConfigService } from '@nestjs/config';
import { JwtService } from '@nestjs/jwt';
import { AuthService } from './auth.service';
//
import { LocalAuthGuard, JwtAuthGuard } from '@/guards';
import { Unprotected } from '@/decorators';

@Controller('auth')
export class AuthController {
  constructor(
    private configService: ConfigService,
    private jwtService: JwtService,
    private readonly authService: AuthService,
  ) {}

  @Unprotected()
  @UseGuards(LocalAuthGuard)
  @Post('login')
  async login(@Request() req) {
    const { user } = req;
    const payload = { username: user.username, sub: user.id };
    return {
      access_token: this.jwtService.sign(payload, {
        secret: this.configService.get<string>('JWT_SECRET'),
      }),
    };
  }

  @UseGuards(LocalAuthGuard)
  @Post('logout')
  async logout(@Request() req) {
    return req.logout();
  }

  @UseGuards(JwtAuthGuard)
  @Get('me')
  async getProfile(@Request() req) {
    return req.user;
  }
}
