import { Module } from '@nestjs/common';
import { WipService } from './wip.service';
import { WipController } from './wip.controller';

@Module({
  controllers: [WipController],
  providers: [WipService],
})
export class WipModule {}
