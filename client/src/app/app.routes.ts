import { Routes } from '@angular/router';
// Routes
import { transactionsRoute } from './transactions/transactions.route';
// Pages
import { LoginComponent } from './login/login.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { NotFoundComponent } from './not-found/not-found.component';

export const appRoutes: Routes = [
  {
    path: 'login',
    redirectTo: '',
  },
  {
    path: 'dashboard',
    component: DashboardComponent,
    title: 'Dashboard',
  },
  transactionsRoute,
  {
    path: '',
    component: LoginComponent,
    pathMatch: 'full',
    title: 'Log in',
  },
  {
    path: '**',
    component: NotFoundComponent,
    title: 'Page Not Found',
  },
];
