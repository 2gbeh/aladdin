import { Route } from '@angular/router';
import { TransactionsComponent } from './transactions.component';
import { TransactionDetailsComponent } from './transaction-details/transaction-details.component';
import { TransactionsLayoutComponent } from '@/components/layouts/transactions-layout/transactions-layout.component';

export const transactionsRoute: Route = {
  path: 'transactions',
  component: TransactionsLayoutComponent,
  children: [
    {
      path: ':id',
      component: TransactionDetailsComponent,
      title: 'Transaction Details',
    },
    {
      path: '',
      component: TransactionsComponent,
      title: 'Transactions',
    },
  ],
};
