import { Routes } from '@angular/router';
import { PATH } from '@/constants/PATH';
// 
import { transactionsRoute } from './transactions/transactions.route';
import { LoginComponent } from './login/login.component';
import { ForgotPasswordComponent } from './forgot-password/forgot-password.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { NotFoundComponent } from './not-found/not-found.component';

export const appRoutes: Routes = [
  {
    path: PATH.login,
    redirectTo: '',
  },
  {
    path: PATH.forgotPassword,
    component: ForgotPasswordComponent,
    title: 'Forgot Password',
  },
  {
    path: PATH.dashboard,
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
