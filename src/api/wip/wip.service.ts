import { Injectable } from '@nestjs/common';
import { CreateWipDto } from './dto/create-wip.dto';
import { UpdateWipDto } from './dto/update-wip.dto';

@Injectable()
export class WipService {
  create(createWipDto: CreateWipDto) {
    return 'This action adds a new wip';
  }

  findAll() {
    return `This action returns all wip`;
  }

  findOne(id: number) {
    return `This action returns a #${id} wip`;
  }

  update(id: number, updateWipDto: UpdateWipDto) {
    return `This action updates a #${id} wip`;
  }

  remove(id: number) {
    return `This action removes a #${id} wip`;
  }
}
