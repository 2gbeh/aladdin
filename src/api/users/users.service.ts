import { Injectable } from '@nestjs/common';
import { User, Prisma } from '@prisma/client';
// 
import { PrismaService } from '@/shared/services';
//
import { IUser, CreateUserDto, UpdateUserDto } from './utils/user.interface';
import { userResource } from './utils/user.resource';

@Injectable()
export class UsersService {
  constructor(private prisma: PrismaService) {}

  create(createUserDto: CreateUserDto) {
    return 'This action adds a new user';
  }

  findAll() {
    return `This action returns all users`;
  }

  async findOne(
    userWhereUniqueInput: Prisma.UserWhereUniqueInput,
  ): Promise<User | null> {
    return this.prisma.user.findUnique({
      where: userWhereUniqueInput,
    });
  }

  async findOneByUsername(username: string): Promise<IUser | undefined> {
    return userResource.getAll.data.find((user) => user.username === username);
  }

  update(id: number, updateUserDto: UpdateUserDto) {
    return `This action updates a #${id} user`;
  }

  remove(id: number) {
    return `This action removes a #${id} user`;
  }
}
