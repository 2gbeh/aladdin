import { PartialType } from '@nestjs/swagger';
import { CreateWipDto } from './create-wip.dto';

export class UpdateWipDto extends PartialType(CreateWipDto) {}
