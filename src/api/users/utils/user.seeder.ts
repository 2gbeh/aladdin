import { PrismaClient } from '@prisma/client';

export async function userSeeder(prisma: PrismaClient) {
  try {
    const res = await prisma.user.upsert({
      where: { username: '2gbeh' },
      update: {},
      create: {
        avatar: 'https://github.com/2gbeh.png',
        username: '2gbeh',
        email: 'dehphantom@yahoo.com',
        password: 'secret',
        pin: '4444',
        otp: 12345,
        verifiedAt: new Date().toJSON(),
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
