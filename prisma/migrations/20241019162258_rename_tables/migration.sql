/*
  Warnings:

  - You are about to drop the `fedora_accounts` table. If the table is not empty, all the data it contains will be lost.
  - You are about to drop the `fedora_bills` table. If the table is not empty, all the data it contains will be lost.
  - You are about to drop the `fedora_cards` table. If the table is not empty, all the data it contains will be lost.
  - You are about to drop the `fedora_categories` table. If the table is not empty, all the data it contains will be lost.
  - You are about to drop the `fedora_preferences` table. If the table is not empty, all the data it contains will be lost.
  - You are about to drop the `fedora_tags` table. If the table is not empty, all the data it contains will be lost.
  - You are about to drop the `fedora_transactions` table. If the table is not empty, all the data it contains will be lost.
  - You are about to drop the `fedora_users` table. If the table is not empty, all the data it contains will be lost.

*/
-- DropForeignKey
ALTER TABLE "_TagToTransaction" DROP CONSTRAINT "_TagToTransaction_A_fkey";

-- DropForeignKey
ALTER TABLE "_TagToTransaction" DROP CONSTRAINT "_TagToTransaction_B_fkey";

-- DropForeignKey
ALTER TABLE "fedora_accounts" DROP CONSTRAINT "fedora_accounts_tenantId_fkey";

-- DropForeignKey
ALTER TABLE "fedora_bills" DROP CONSTRAINT "fedora_bills_accountId_fkey";

-- DropForeignKey
ALTER TABLE "fedora_bills" DROP CONSTRAINT "fedora_bills_tenantId_fkey";

-- DropForeignKey
ALTER TABLE "fedora_cards" DROP CONSTRAINT "fedora_cards_tenantId_fkey";

-- DropForeignKey
ALTER TABLE "fedora_preferences" DROP CONSTRAINT "fedora_preferences_tenantId_fkey";

-- DropForeignKey
ALTER TABLE "fedora_tags" DROP CONSTRAINT "fedora_tags_tenantId_fkey";

-- DropForeignKey
ALTER TABLE "fedora_transactions" DROP CONSTRAINT "fedora_transactions_accountId_fkey";

-- DropForeignKey
ALTER TABLE "fedora_transactions" DROP CONSTRAINT "fedora_transactions_cardId_fkey";

-- DropForeignKey
ALTER TABLE "fedora_transactions" DROP CONSTRAINT "fedora_transactions_categoryId_fkey";

-- DropForeignKey
ALTER TABLE "fedora_transactions" DROP CONSTRAINT "fedora_transactions_tenantId_fkey";

-- DropTable
DROP TABLE "fedora_accounts";

-- DropTable
DROP TABLE "fedora_bills";

-- DropTable
DROP TABLE "fedora_cards";

-- DropTable
DROP TABLE "fedora_categories";

-- DropTable
DROP TABLE "fedora_preferences";

-- DropTable
DROP TABLE "fedora_tags";

-- DropTable
DROP TABLE "fedora_transactions";

-- DropTable
DROP TABLE "fedora_users";

-- CreateTable
CREATE TABLE "accounts" (
    "id" SERIAL NOT NULL,
    "avatar" VARCHAR,
    "name" VARCHAR NOT NULL,
    "displayName" VARCHAR,
    "phone" VARCHAR,
    "bio" VARCHAR,
    "isFavorite" BOOLEAN NOT NULL DEFAULT false,
    "isPrivate" BOOLEAN NOT NULL DEFAULT false,
    "createdAt" TIMESTAMP(3) NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "updatedAt" TIMESTAMP(3) NOT NULL,
    "deletedAt" TIMESTAMP(3),
    "tenantId" UUID NOT NULL,

    CONSTRAINT "accounts_pkey" PRIMARY KEY ("id")
);

-- CreateTable
CREATE TABLE "bills" (
    "id" SERIAL NOT NULL,
    "item" VARCHAR NOT NULL,
    "description" VARCHAR,
    "qty" INTEGER NOT NULL DEFAULT 1,
    "price" MONEY NOT NULL DEFAULT 0.00,
    "paidAt" TIMESTAMP(3),
    "createdAt" TIMESTAMP(3) NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "updatedAt" TIMESTAMP(3) NOT NULL,
    "deletedAt" TIMESTAMP(3),
    "accountId" INTEGER NOT NULL,
    "tenantId" UUID NOT NULL,

    CONSTRAINT "bills_pkey" PRIMARY KEY ("id")
);

-- CreateTable
CREATE TABLE "cards" (
    "id" SERIAL NOT NULL,
    "logo" VARCHAR,
    "name" VARCHAR NOT NULL,
    "displayName" VARCHAR,
    "cardNumber" VARCHAR,
    "color" VARCHAR,
    "createdAt" TIMESTAMP(3) NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "updatedAt" TIMESTAMP(3) NOT NULL,
    "deletedAt" TIMESTAMP(3),
    "tenantId" UUID NOT NULL,

    CONSTRAINT "cards_pkey" PRIMARY KEY ("id")
);

-- CreateTable
CREATE TABLE "categories" (
    "id" SERIAL NOT NULL,
    "name" VARCHAR NOT NULL,
    "description" VARCHAR,

    CONSTRAINT "categories_pkey" PRIMARY KEY ("id")
);

-- CreateTable
CREATE TABLE "preferences" (
    "id" SERIAL NOT NULL,
    "darkMode" BOOLEAN NOT NULL DEFAULT false,
    "maskedMode" BOOLEAN NOT NULL DEFAULT false,
    "prototypeMode" BOOLEAN NOT NULL DEFAULT false,
    "incognitoMode" BOOLEAN NOT NULL DEFAULT false,
    "googleAuth" JSONB,
    "githubAuth" JSONB,
    "paystack" JSONB,
    "createdAt" TIMESTAMP(3) NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "updatedAt" TIMESTAMP(3) NOT NULL,
    "deletedAt" TIMESTAMP(3),
    "tenantId" UUID NOT NULL,

    CONSTRAINT "preferences_pkey" PRIMARY KEY ("id")
);

-- CreateTable
CREATE TABLE "tags" (
    "id" SERIAL NOT NULL,
    "name" VARCHAR NOT NULL,
    "description" VARCHAR,
    "createdAt" TIMESTAMP(3) NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "updatedAt" TIMESTAMP(3) NOT NULL,
    "deletedAt" TIMESTAMP(3),
    "tenantId" UUID NOT NULL,

    CONSTRAINT "tags_pkey" PRIMARY KEY ("id")
);

-- CreateTable
CREATE TABLE "transactions" (
    "id" SERIAL NOT NULL,
    "type" "TransactionType" NOT NULL DEFAULT 'DEBIT',
    "amount" MONEY NOT NULL DEFAULT 0.00,
    "outstanding" MONEY NOT NULL DEFAULT 0.00,
    "narration" VARCHAR,
    "repeatsPerMonth" INTEGER NOT NULL DEFAULT 0,
    "is_draft" BOOLEAN NOT NULL DEFAULT false,
    "createdAt" TIMESTAMP(3) NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "updatedAt" TIMESTAMP(3) NOT NULL,
    "deletedAt" TIMESTAMP(3),
    "accountId" INTEGER NOT NULL,
    "cardId" INTEGER NOT NULL,
    "categoryId" INTEGER NOT NULL,
    "tenantId" UUID NOT NULL,

    CONSTRAINT "transactions_pkey" PRIMARY KEY ("id")
);

-- CreateTable
CREATE TABLE "users" (
    "id" UUID NOT NULL DEFAULT gen_random_uuid(),
    "avatar" VARCHAR,
    "username" VARCHAR NOT NULL,
    "email" VARCHAR NOT NULL,
    "password" VARCHAR NOT NULL,
    "pin" INTEGER,
    "biometric" JSONB,
    "otp" INTEGER,
    "balance" MONEY NOT NULL DEFAULT 0.00,
    "notes" JSONB,
    "verifiedAt" TIMESTAMP(3),
    "createdAt" TIMESTAMP(3) NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "updatedAt" TIMESTAMP(3) NOT NULL,
    "deletedAt" TIMESTAMP(3),

    CONSTRAINT "users_pkey" PRIMARY KEY ("id")
);

-- CreateIndex
CREATE UNIQUE INDEX "accounts_name_key" ON "accounts"("name");

-- CreateIndex
CREATE INDEX "accounts_displayName_idx" ON "accounts"("displayName");

-- CreateIndex
CREATE INDEX "bills_item_idx" ON "bills"("item");

-- CreateIndex
CREATE UNIQUE INDEX "cards_name_key" ON "cards"("name");

-- CreateIndex
CREATE INDEX "cards_displayName_idx" ON "cards"("displayName");

-- CreateIndex
CREATE UNIQUE INDEX "categories_name_key" ON "categories"("name");

-- CreateIndex
CREATE UNIQUE INDEX "preferences_tenantId_key" ON "preferences"("tenantId");

-- CreateIndex
CREATE UNIQUE INDEX "tags_name_key" ON "tags"("name");

-- CreateIndex
CREATE UNIQUE INDEX "users_username_key" ON "users"("username");

-- CreateIndex
CREATE UNIQUE INDEX "users_email_key" ON "users"("email");

-- CreateIndex
CREATE INDEX "users_username_idx" ON "users"("username");

-- AddForeignKey
ALTER TABLE "accounts" ADD CONSTRAINT "accounts_tenantId_fkey" FOREIGN KEY ("tenantId") REFERENCES "users"("id") ON DELETE RESTRICT ON UPDATE CASCADE;

-- AddForeignKey
ALTER TABLE "bills" ADD CONSTRAINT "bills_accountId_fkey" FOREIGN KEY ("accountId") REFERENCES "accounts"("id") ON DELETE RESTRICT ON UPDATE CASCADE;

-- AddForeignKey
ALTER TABLE "bills" ADD CONSTRAINT "bills_tenantId_fkey" FOREIGN KEY ("tenantId") REFERENCES "users"("id") ON DELETE RESTRICT ON UPDATE CASCADE;

-- AddForeignKey
ALTER TABLE "cards" ADD CONSTRAINT "cards_tenantId_fkey" FOREIGN KEY ("tenantId") REFERENCES "users"("id") ON DELETE RESTRICT ON UPDATE CASCADE;

-- AddForeignKey
ALTER TABLE "preferences" ADD CONSTRAINT "preferences_tenantId_fkey" FOREIGN KEY ("tenantId") REFERENCES "users"("id") ON DELETE RESTRICT ON UPDATE CASCADE;

-- AddForeignKey
ALTER TABLE "tags" ADD CONSTRAINT "tags_tenantId_fkey" FOREIGN KEY ("tenantId") REFERENCES "users"("id") ON DELETE RESTRICT ON UPDATE CASCADE;

-- AddForeignKey
ALTER TABLE "transactions" ADD CONSTRAINT "transactions_accountId_fkey" FOREIGN KEY ("accountId") REFERENCES "accounts"("id") ON DELETE RESTRICT ON UPDATE CASCADE;

-- AddForeignKey
ALTER TABLE "transactions" ADD CONSTRAINT "transactions_cardId_fkey" FOREIGN KEY ("cardId") REFERENCES "cards"("id") ON DELETE RESTRICT ON UPDATE CASCADE;

-- AddForeignKey
ALTER TABLE "transactions" ADD CONSTRAINT "transactions_categoryId_fkey" FOREIGN KEY ("categoryId") REFERENCES "categories"("id") ON DELETE RESTRICT ON UPDATE CASCADE;

-- AddForeignKey
ALTER TABLE "transactions" ADD CONSTRAINT "transactions_tenantId_fkey" FOREIGN KEY ("tenantId") REFERENCES "users"("id") ON DELETE RESTRICT ON UPDATE CASCADE;

-- AddForeignKey
ALTER TABLE "_TagToTransaction" ADD CONSTRAINT "_TagToTransaction_A_fkey" FOREIGN KEY ("A") REFERENCES "tags"("id") ON DELETE CASCADE ON UPDATE CASCADE;

-- AddForeignKey
ALTER TABLE "_TagToTransaction" ADD CONSTRAINT "_TagToTransaction_B_fkey" FOREIGN KEY ("B") REFERENCES "transactions"("id") ON DELETE CASCADE ON UPDATE CASCADE;
