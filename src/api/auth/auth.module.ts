import { Module } from '@nestjs/common';
import { PassportModule } from '@nestjs/passport';
import { JwtModule } from '@nestjs/jwt';
//
import { LocalStrategy, JwtStrategy } from '@/shared/strategies';
import { UsersModule } from '../users/users.module';
//
import { AuthService } from './auth.service';
import { AuthController } from './auth.controller';

@Module({
  imports: [
    PassportModule,
    JwtModule.register({
      secret: process.env.SESSION_SECRET!,
      secretOrPrivateKey: process.env.SESSION_SECRET!,
      signOptions: { expiresIn: '7d' },
    }),
    UsersModule,
  ],
  providers: [LocalStrategy, JwtStrategy, AuthService],
  controllers: [AuthController],
  exports: [AuthService],
})
export class AuthModule {}
