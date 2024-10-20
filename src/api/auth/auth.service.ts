import { Injectable } from '@nestjs/common';
import { compare } from 'bcryptjs';
//
import { IUser } from '../users/utils/user.interface';
import { UsersService } from '../users/users.service';
//
import { LoginDto } from './utils/auth.interface';

@Injectable()
export class AuthService {
  constructor(private usersService: UsersService) {}

  async authenticate(body: LoginDto): Promise<Omit<IUser, 'password'>> {
    console.log('🚀 ~ AuthService ~ login ~ body:', body);
    const user = await this.usersService.findOneByUsername(body.email);
    if (user) {
      if (await compare(body.password, user.password)) {
        const { password, ...result } = user;
        return result;
      }
    }
    return null;
  }
}
