-- CreateEnum
CREATE TYPE "Role" AS ENUM ('USER', 'ADMIN');

-- CreateEnum
CREATE TYPE "TransactionType" AS ENUM ('CREDIT', 'DEBIT');

-- CreateTable
CREATE TABLE "fedora_accounts" (
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

    CONSTRAINT "fedora_accounts_pkey" PRIMARY KEY ("id")
);

-- CreateTable
CREATE TABLE "fedora_bills" (
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

    CONSTRAINT "fedora_bills_pkey" PRIMARY KEY ("id")
);

-- CreateTable
CREATE TABLE "fedora_cards" (
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

    CONSTRAINT "fedora_cards_pkey" PRIMARY KEY ("id")
);

-- CreateTable
CREATE TABLE "fedora_categories" (
    "id" SERIAL NOT NULL,
    "name" VARCHAR NOT NULL,
    "description" VARCHAR,

    CONSTRAINT "fedora_categories_pkey" PRIMARY KEY ("id")
);

-- CreateTable
CREATE TABLE "fedora_preferences" (
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

    CONSTRAINT "fedora_preferences_pkey" PRIMARY KEY ("id")
);

-- CreateTable
CREATE TABLE "fedora_tags" (
    "id" SERIAL NOT NULL,
    "name" VARCHAR NOT NULL,
    "description" VARCHAR,
    "createdAt" TIMESTAMP(3) NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "updatedAt" TIMESTAMP(3) NOT NULL,
    "deletedAt" TIMESTAMP(3),
    "tenantId" UUID NOT NULL,

    CONSTRAINT "fedora_tags_pkey" PRIMARY KEY ("id")
);

-- CreateTable
CREATE TABLE "fedora_transactions" (
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

    CONSTRAINT "fedora_transactions_pkey" PRIMARY KEY ("id")
);

-- CreateTable
CREATE TABLE "fedora_users" (
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

    CONSTRAINT "fedora_users_pkey" PRIMARY KEY ("id")
);

-- CreateTable
CREATE TABLE "_TagToTransaction" (
    "A" INTEGER NOT NULL,
    "B" INTEGER NOT NULL
);

-- CreateIndex
CREATE UNIQUE INDEX "fedora_accounts_name_key" ON "fedora_accounts"("name");

-- CreateIndex
CREATE INDEX "fedora_accounts_displayName_idx" ON "fedora_accounts"("displayName");

-- CreateIndex
CREATE INDEX "fedora_bills_item_idx" ON "fedora_bills"("item");

-- CreateIndex
CREATE UNIQUE INDEX "fedora_cards_name_key" ON "fedora_cards"("name");

-- CreateIndex
CREATE INDEX "fedora_cards_displayName_idx" ON "fedora_cards"("displayName");

-- CreateIndex
CREATE UNIQUE INDEX "fedora_categories_name_key" ON "fedora_categories"("name");

-- CreateIndex
CREATE UNIQUE INDEX "fedora_preferences_tenantId_key" ON "fedora_preferences"("tenantId");

-- CreateIndex
CREATE UNIQUE INDEX "fedora_tags_name_key" ON "fedora_tags"("name");

-- CreateIndex
CREATE UNIQUE INDEX "fedora_users_username_key" ON "fedora_users"("username");

-- CreateIndex
CREATE UNIQUE INDEX "fedora_users_email_key" ON "fedora_users"("email");

-- CreateIndex
CREATE INDEX "fedora_users_username_idx" ON "fedora_users"("username");

-- CreateIndex
CREATE UNIQUE INDEX "_TagToTransaction_AB_unique" ON "_TagToTransaction"("A", "B");

-- CreateIndex
CREATE INDEX "_TagToTransaction_B_index" ON "_TagToTransaction"("B");

-- AddForeignKey
ALTER TABLE "fedora_accounts" ADD CONSTRAINT "fedora_accounts_tenantId_fkey" FOREIGN KEY ("tenantId") REFERENCES "fedora_users"("id") ON DELETE RESTRICT ON UPDATE CASCADE;

-- AddForeignKey
ALTER TABLE "fedora_bills" ADD CONSTRAINT "fedora_bills_accountId_fkey" FOREIGN KEY ("accountId") REFERENCES "fedora_accounts"("id") ON DELETE RESTRICT ON UPDATE CASCADE;

-- AddForeignKey
ALTER TABLE "fedora_bills" ADD CONSTRAINT "fedora_bills_tenantId_fkey" FOREIGN KEY ("tenantId") REFERENCES "fedora_users"("id") ON DELETE RESTRICT ON UPDATE CASCADE;

-- AddForeignKey
ALTER TABLE "fedora_cards" ADD CONSTRAINT "fedora_cards_tenantId_fkey" FOREIGN KEY ("tenantId") REFERENCES "fedora_users"("id") ON DELETE RESTRICT ON UPDATE CASCADE;

-- AddForeignKey
ALTER TABLE "fedora_preferences" ADD CONSTRAINT "fedora_preferences_tenantId_fkey" FOREIGN KEY ("tenantId") REFERENCES "fedora_users"("id") ON DELETE RESTRICT ON UPDATE CASCADE;

-- AddForeignKey
ALTER TABLE "fedora_tags" ADD CONSTRAINT "fedora_tags_tenantId_fkey" FOREIGN KEY ("tenantId") REFERENCES "fedora_users"("id") ON DELETE RESTRICT ON UPDATE CASCADE;

-- AddForeignKey
ALTER TABLE "fedora_transactions" ADD CONSTRAINT "fedora_transactions_accountId_fkey" FOREIGN KEY ("accountId") REFERENCES "fedora_accounts"("id") ON DELETE RESTRICT ON UPDATE CASCADE;

-- AddForeignKey
ALTER TABLE "fedora_transactions" ADD CONSTRAINT "fedora_transactions_cardId_fkey" FOREIGN KEY ("cardId") REFERENCES "fedora_cards"("id") ON DELETE RESTRICT ON UPDATE CASCADE;

-- AddForeignKey
ALTER TABLE "fedora_transactions" ADD CONSTRAINT "fedora_transactions_categoryId_fkey" FOREIGN KEY ("categoryId") REFERENCES "fedora_categories"("id") ON DELETE RESTRICT ON UPDATE CASCADE;

-- AddForeignKey
ALTER TABLE "fedora_transactions" ADD CONSTRAINT "fedora_transactions_tenantId_fkey" FOREIGN KEY ("tenantId") REFERENCES "fedora_users"("id") ON DELETE RESTRICT ON UPDATE CASCADE;

-- AddForeignKey
ALTER TABLE "_TagToTransaction" ADD CONSTRAINT "_TagToTransaction_A_fkey" FOREIGN KEY ("A") REFERENCES "fedora_tags"("id") ON DELETE CASCADE ON UPDATE CASCADE;

-- AddForeignKey
ALTER TABLE "_TagToTransaction" ADD CONSTRAINT "_TagToTransaction_B_fkey" FOREIGN KEY ("B") REFERENCES "fedora_transactions"("id") ON DELETE CASCADE ON UPDATE CASCADE;
