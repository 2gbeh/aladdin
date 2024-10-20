import { Injectable } from '@nestjs/common';
//
import { IUser } from '../users/utils/user.interface';
import { UsersService } from '../users/users.service';
// 
import { LoginDto } from './utils/auth.interface';

@Injectable()
export class AuthService {
  constructor(private usersService: UsersService) {}

  async login(body: LoginDto): Promise<Omit<IUser, 'password'>> {
    console.log('🚀 ~ AuthService ~ login ~ body:', body);
    const user = await this.usersService.findOneByUsername(body.email);
    if (user && user.password === body.password) {
      const { password, ...result } = user;
      return result;
    }
    return null;
  }
}
