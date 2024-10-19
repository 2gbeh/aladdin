import { Module } from '@nestjs/common';
import { PreferencesService } from './preferences.service';
import { PreferencesController } from './preferences.controller';

@Module({
  controllers: [PreferencesController],
  providers: [PreferencesService],
})
export class PreferencesModule {}
