import { PrismaClient } from '@prisma/client';
import { cardSeeder } from '../src/api/cards/utils/card.seeder';
import { categorySeeder } from '../src/api/categories/utils/category.seeder';
import { userSeeder } from '../src/api/users/utils/user.seeder';

const prisma = new PrismaClient();

async function main() {
  await Promise.all([
    cardSeeder(prisma),
    categorySeeder(prisma),
    userSeeder(prisma),
  ]);
}
// execute
main()
  .then(async () => {
    await prisma.$disconnect();
  })
  .catch(async (err) => {
    console.log('🚀 ~ PrismaSeedError:', err);
    await prisma.$disconnect();
    process.exit(1);
  });
