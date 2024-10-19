import { PrismaClient } from '@prisma/client';
import { CATEGORY } from './category.constant';

export async function categorySeeder(prisma: PrismaClient) {
  try {
    const count = await prisma.category.count();
    // if table data not populated
    if (count < CATEGORY.list.length) {
      // truncate table
      await prisma.$executeRawUnsafe(
        `TRUNCATE TABLE "public"."categories" CASCADE;`,
      );
      // seed table
      const res = await prisma.category.createMany({
        data: CATEGORY.list.map((name) => ({
          name,
        })),
        skipDuplicates: true,
      });
      //
      console.log('🚀 ~ categorySeeder ~ res:', res);
      return res;
    }
  } catch (err) {
    console.error('🚀 ~ categorySeeder ~ err:', err);
  }
}
