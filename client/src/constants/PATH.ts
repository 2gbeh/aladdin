import { Identifier } from "@/types/common.type";

export const PATH = {
  // Auth
  login: 'login',
  forgotPassword: 'forgot-password',
  // Dashboard
  dashboard: 'dashboard',
  // Transactions
  transactions: 'transactions',
  createTransaction: 'transactions/create',
  transactionDetails: (identifier: Identifier) => `transactions/${identifier}`,
  editTransaction: (identifier: Identifier) => `transactions/${identifier}/edit`,
} as const