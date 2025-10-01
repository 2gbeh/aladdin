export const PATH = {
  // Auth
  login: 'login',
  forgotPassword: 'forgot-password',
  // Dashboard
  dashboard: 'dashboard',
  // Transactions
  transactions: 'transactions',
  createTransaction: 'transactions/create',
  transactionDetails: (id: string) => `transactions/${id}`,
  editTransaction: (id: string) => `transactions/${id}/edit`,
} as const