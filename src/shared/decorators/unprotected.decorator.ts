import { SetMetadata } from '@nestjs/common';

export const IS_UNPROTECTED_KEY = 'isUnprotected';
export const Unprotected = () => SetMetadata(IS_UNPROTECTED_KEY, true);