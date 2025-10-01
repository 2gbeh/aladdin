import { Route } from '@angular/router';
import { PATH } from '@/constants/PATH';
// 
import { TransactionsLayoutComponent } from '@/components/species/transactions/transactions-layout/transactions-layout.component';
import { TransactionsComponent } from './transactions.component';
import { TransactionDetailsComponent } from './transaction-details/transaction-details.component';
import { CreateTransactionComponent } from './create-transaction/create-transaction.component';
import { EditTransactionComponent } from './edit-transaction/edit-transaction.component';

export const transactionsRoute: Route = {
  path: PATH.transactions,
  component: TransactionsLayoutComponent,
  children: [
    {
      path: 'create',
      component: CreateTransactionComponent,
      title: 'Create Transaction',
    },
    {
      path: ':identifier/edit',
      component: EditTransactionComponent,
      title: 'Edit Transaction',
    },
    {
      path: ':identifier',
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
