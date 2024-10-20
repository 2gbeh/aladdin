import { APP_GUARD } from '@nestjs/core';
import { Module } from '@nestjs/common';
import { ConfigModule } from '@nestjs/config';
//
import { envValidationSchema } from './shared/validation';
import { JwtAuthGuard } from './shared/guards';
import { PrismaService } from './shared/services';
//
import { AuthModule } from './api/auth/auth.module';
import { UsersModule } from './api/users/users.module';
import { PreferencesModule } from './api/preferences/preferences.module';
import { AccountsModule } from './api/accounts/accounts.module';
import { CardsModule } from './api/cards/cards.module';
import { CategoriesModule } from './api/categories/categories.module';
import { TagsModule } from './api/tags/tags.module';
import { TransactionsModule } from './api/transactions/transactions.module';
import { BillsModule } from './api/bills/bills.module';
import { WipModule } from './api/wip/wip.module';

@Module({
  imports: [
    ConfigModule.forRoot({
      isGlobal: true,
      expandVariables: true,
      validationSchema: envValidationSchema,
    }),
    AuthModule,
    UsersModule,
    PreferencesModule,
    AccountsModule,
    CardsModule,
    CategoriesModule,
    TagsModule,
    TransactionsModule,
    BillsModule,
    WipModule,
  ],
  providers: [
    {
      provide: APP_GUARD,
      useClass: JwtAuthGuard,
    },
    PrismaService,
  ],
})
export class AppModule {}
