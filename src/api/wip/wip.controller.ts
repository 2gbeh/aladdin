import { Controller, Get, Post, Body, Patch, Param, Delete } from '@nestjs/common';
import { WipService } from './wip.service';
import { CreateWipDto } from './dto/create-wip.dto';
import { UpdateWipDto } from './dto/update-wip.dto';

@Controller('wip')
export class WipController {
  constructor(private readonly wipService: WipService) {}

  @Post()
  create(@Body() createWipDto: CreateWipDto) {
    return this.wipService.create(createWipDto);
  }

  @Get()
  findAll() {
    return this.wipService.findAll();
  }

  @Get(':id')
  findOne(@Param('id') id: string) {
    return this.wipService.findOne(+id);
  }

  @Patch(':id')
  update(@Param('id') id: string, @Body() updateWipDto: UpdateWipDto) {
    return this.wipService.update(+id, updateWipDto);
  }

  @Delete(':id')
  remove(@Param('id') id: string) {
    return this.wipService.remove(+id);
  }
}
