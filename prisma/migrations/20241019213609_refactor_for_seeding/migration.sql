-- DropForeignKey
ALTER TABLE "cards" DROP CONSTRAINT "cards_tenantId_fkey";

-- AlterTable
ALTER TABLE "cards" ALTER COLUMN "tenantId" DROP NOT NULL;

-- AlterTable
ALTER TABLE "users" ALTER COLUMN "pin" SET DATA TYPE VARCHAR;

-- AddForeignKey
ALTER TABLE "cards" ADD CONSTRAINT "cards_tenantId_fkey" FOREIGN KEY ("tenantId") REFERENCES "users"("id") ON DELETE SET NULL ON UPDATE CASCADE;
