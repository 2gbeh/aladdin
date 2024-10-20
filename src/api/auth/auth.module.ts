import { Module } from '@nestjs/common';
import { PassportModule } from '@nestjs/passport';
import { JwtModule } from '@nestjs/jwt';
//
import { LocalStrategy, JwtStrategy } from '@/shared/strategies';
//
import { AuthService } from './auth.service';
import { AuthController } from './auth.controller';
import { UsersModule } from '../users/users.module';

@Module({
  imports: [
    PassportModule,
    JwtModule.register({
      secret: process.env.JWT_SECRET!,
      secretOrPrivateKey: process.env.JWT_SECRET!,
      signOptions: { expiresIn: process.env.JWT_SECRET_EXPIRES! },
    }),
    UsersModule,
  ],
  providers: [LocalStrategy, JwtStrategy, AuthService],
  controllers: [AuthController],
  exports: [AuthService],
})
export class AuthModule {}
