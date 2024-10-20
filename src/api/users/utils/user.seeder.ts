import { PrismaClient } from '@prisma/client';
import { hash } from 'bcryptjs';
// 
import { AppHelper } from '@/utils/app.helper';

export async function userSeeder(prisma: PrismaClient) {
  try {
    const hashedPassword = await hash('secret', 10);
    const res = await prisma.user.upsert({
      where: { username: '2gbeh' },
      update: {},
      create: {
        avatar: 'https://github.com/2gbeh.png',
        username: '2gbeh',
        email: 'dehphantom@yahoo.com',
        password: hashedPassword,
        pin: '3142',
        otp: 12345,
        verifiedAt: AppHelper.dt,
        preference: {
          create: {
            darkMode: true,
            prototypeMode: true,
          },
        },
      },
    });
    //
    console.log('🚀 ~ userSeeder ~ res:', res);
    return res;
  } catch (err) {
    console.error('🚀 ~ userSeeder ~ err:', err);
  }
}
