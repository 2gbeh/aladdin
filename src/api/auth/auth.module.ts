import { Module } from '@nestjs/common';
import { PassportModule } from '@nestjs/passport';
import { JwtModule } from '@nestjs/jwt';
import { AuthService } from './auth.service';
import { AuthController } from './auth.controller';
//
import { LocalStrategy, JwtStrategy } from '@/strategies';
import { UsersModule } from '../users/users.module';

@Module({
  imports: [
    PassportModule,
    JwtModule.register({
      secret: process.env.SESSION_SECRET!,
      signOptions: { expiresIn: '7d' },
    }),
    UsersModule,
  ],
  providers: [LocalStrategy, JwtStrategy, AuthService],
  controllers: [AuthController],
  exports: [AuthService],
})
export class AuthModule {}
