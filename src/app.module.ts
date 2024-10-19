import { APP_GUARD } from '@nestjs/core';
import { Module } from '@nestjs/common';
import { ConfigModule } from '@nestjs/config';
//
import { UsersModule } from './api/users/users.module';
import { AuthModule } from './api/auth/auth.module';
import { envValidationSchema } from './validation';
import { JwtAuthGuard } from './guards';

@Module({
  imports: [
    ConfigModule.forRoot({
      isGlobal: true,
      expandVariables: true,
      validationSchema: envValidationSchema,
    }),
    UsersModule,
    AuthModule,
  ],
  providers: [
    {
      provide: APP_GUARD,
      useClass: JwtAuthGuard,
    },
  ],
})
export class AppModule {}
