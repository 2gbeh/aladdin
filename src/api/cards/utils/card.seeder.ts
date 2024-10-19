import { PrismaClient } from '@prisma/client';

export async function cardSeeder(prisma: PrismaClient) {
  try {
    const res = await prisma.card.upsert({
      where: { name: 'Cash' },
      update: {},
      create: {
        name: 'Cash',
        color: '#00d632',
      },
    });
    //
    console.log('🚀 ~ cardSeeder ~ res:', res);
    return res;
  } catch (err) {
    console.error('🚀 ~ cardSeeder ~ err:', err);
  }
}
