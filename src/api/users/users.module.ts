import { Module } from '@nestjs/common';
// 
import { PrismaService } from '@/shared/services';
// 
import { UsersService } from './users.service';
import { UsersController } from './users.controller';

@Module({
  providers: [UsersService, PrismaService],
  controllers: [UsersController],
  exports: [UsersService],
})
export class UsersModule {}
