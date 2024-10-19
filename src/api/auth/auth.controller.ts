import { Controller, Post, Get, UseGuards, Request } from '@nestjs/common';
import { AuthService } from './auth.service';
//
import { LocalAuthGuard, JwtAuthGuard } from '@/guards';
import { Unprotected } from '@/decorators';

@Controller('auth')
export class AuthController {
  constructor(private readonly authService: AuthService) {}

  // @Unprotected()
  @UseGuards(LocalAuthGuard)
  @Post('login')
  async login(@Request() req) {
    return this.authService.login(req.user);
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
