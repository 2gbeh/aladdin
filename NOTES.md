# Notes

## Features

```md
- search, sort and filters
- soft-delete
- multi-tenancy
- dark mode
- masked mode
- # prototype mode
- # incognito mode
- oauth (google, github)
- # biometic login (fingerprint)
- paystack wallet
- # recurring TR
- # draft TR
- # budget
- analytics
```

## Installation

```bash
$ npm i -g @nestjs/cli@latest
$ nest -v
$ nest new aladdin
$ cd aladdin
$ npm run start:dev
```

### Setup

```bash
$ git clone https://github.com/2gbeh/aladdin.git
$ cd aladdin
$ npm cache clean --force

# or npm install --legacy-peer-deps
$ npm install

$ npm run start:dev
```

> Server running on http://127.0.0.1:3000

## [Swagger](https://docs.nestjs.com/openapi/introduction)

```bash
$ npm install --save @nestjs/swagger
```

## [Passport](https://docs.nestjs.com/recipes/passport)

```bash
$ npm install --save @nestjs/passport passport passport-local
$ npm install --save-dev @types/passport-local
$ npm install --save @nestjs/jwt passport-jwt
$ npm install --save-dev @types/passport-jwt

# *Pluralize resources where applicable
$ nest g resource api/auth --no-spec
$ nest g resource api/users --no-spec

# Generate jwt secret
$ openssl rand -base64 32
```

## [.env](https://docs.nestjs.com/techniques/configuration)

```bash
$ npm i --save @nestjs/config
$ npm install --save joi
```

```ts
// ./src/validation/env.validation.ts

import * as Joi from 'joi';

export const envValidationSchema = Joi.object({
  NODE_ENV: Joi.string()
    .valid('development', 'production', 'test')
    .default('development'),
  PORT: Joi.number().default(3000),
  JWT_SECRET: Joi.string().required(),
  POSTGRES_PRISMA_URL: Joi.string().uri().required(),
  POSTGRES_URL_NON_POOLING: Joi.string().uri().required(),
});
```

## [Render](https://dashboard.render.com/web/srv-cs9ddnrqf0us739et8eg/settings)

```bash
# Build command
$ npm install; npm run build

# Start Command
$ npm run start:prod
```

## [Prisma](https://docs.nestjs.com/recipes/prisma)

```bash
$ npm install prisma --save-dev
$ npx prisma init
$ npm install @prisma/client

# SOLID https://www.prisma.io/blog/organize-your-prisma-schema-with-multi-file-support

# Push local schema changes (Ex. --name `migration_name`)
$ npx prisma migrate dev --name init

# Pull local schema changes
$ npx prisma generate

# SEED https://www.prisma.io/docs/orm/prisma-migrate/workflows/seeding#integrated-seeding-with-prisma-migrate

$ npx prisma db seed
```

```prisma
generator client {
  provider        = "prisma-client-js"
  previewFeatures = ["prismaSchemaFolder", "relationJoins", "omitApi"]
}

datasource db {
  provider  = "postgresql"
  url       = env("DATABASE_URL") // uses connection pooling
  directUrl = env("DATABASE_URL_NON_POOLING") // uses a direct connection
}

enum Role {
  USER
  ADMIN
}
```

## [Supabase](https://supabase.com/dashboard/project/gfkkemdbbevelampyzcj/database/tables)

```bash
# Visit above link
```

## Entities

```md
- # auth
- users
- cards
- accounts
- categories
- tags
- transactions
- bills
- preferences
```

## Relations

```md
- Users <> Preferences (one-to-one)
- Accounts <> Bills (one-to-many)
- Transactions <> Tags (many-to-many)
```
