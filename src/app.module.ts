import { APP_GUARD } from '@nestjs/core';
import { Module } from '@nestjs/common';
import { ConfigModule } from '@nestjs/config';
//
import { UsersModule } from './api/users/users.module';
import { AuthModule } from './api/auth/auth.module';
import { envValidationSchema } from './validation';
import { JwtAuthGuard } from './guards';
import { CategoriesModule } from './api/categories/categories.module';
import { CardsModule } from './api/cards/cards.module';
import { AccountsModule } from './api/accounts/accounts.module';
import { TagsModule } from './api/tags/tags.module';
import { TransactionsModule } from './api/transactions/transactions.module';
import { BillsModule } from './api/bills/bills.module';
import { PreferencesModule } from './api/preferences/preferences.module';

@Module({
  imports: [
    ConfigModule.forRoot({
      isGlobal: true,
      expandVariables: true,
      validationSchema: envValidationSchema,
    }),
    UsersModule,
    AuthModule,
    CategoriesModule,
    CardsModule,
    AccountsModule,
    TagsModule,
    TransactionsModule,
    BillsModule,
    PreferencesModule,
  ],
  providers: [
    {
      provide: APP_GUARD,
      useClass: JwtAuthGuard,
    },
  ],
})
export class AppModule {}
