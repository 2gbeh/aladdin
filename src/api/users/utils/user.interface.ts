import { Prisma, User } from '@prisma/client';

export interface IUser {
  id: number;
  username: string;
  password: string;
}

export interface UserEntity extends User {}

export type CreateUserDto = Prisma.UserCreateInput;

export type UpdateUserDto = Prisma.UserUpdateInput;

export type QueryUserDto = Prisma.UserWhereUniqueInput;
