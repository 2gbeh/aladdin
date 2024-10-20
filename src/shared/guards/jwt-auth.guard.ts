import { Reflector } from '@nestjs/core';
import { ExecutionContext, Injectable } from '@nestjs/common';
import { AuthGuard } from '@nestjs/passport';
//
import { IS_UNPROTECTED_KEY } from '@/shared/decorators';

@Injectable()
export class JwtAuthGuard extends AuthGuard('jwt') {
  constructor(private reflector: Reflector) {
    super();
  }

  canActivate(context: ExecutionContext) {
    const isUnprotected = this.reflector.getAllAndOverride<boolean>(
      IS_UNPROTECTED_KEY,
      [context.getHandler(), context.getClass()],
    );
    if (isUnprotected) {
      return true;
    }
    return super.canActivate(context);
  }
}
