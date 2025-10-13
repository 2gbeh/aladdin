type Prototype = Record<string, {
  loader?: number
  portal?: number
  formData?: number
  action?: number
}>

export const PROTOTYPING: Prototype = {
  auth: {
    formData: 1,
  },
} as const