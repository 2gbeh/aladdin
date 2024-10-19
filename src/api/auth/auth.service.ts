import { Injectable } from '@nestjs/common';
//
import { ILoginPayload } from './utils/auth.interface';
import { IUser } from '../users/utils/user.interface';
import { UsersService } from '../users/users.service';

@Injectable()
export class AuthService {
  constructor(private usersService: UsersService) {}

  async login(body: ILoginPayload): Promise<Omit<IUser, 'password'>> {
    console.log("🚀 ~ AuthService ~ login ~ body:", body)
    const user = await this.usersService.findOneByUsername(body.email);
    if (user && user.password === body.password) {
      const { password, ...result } = user;
      return result;
    }
    return null;
  }
}
