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

## Setup

```bash
$ npm i -g @nestjs/cli@latest
$ nest -v
$ nest new aladdin
$ cd aladdin
$ npm run start:dev
```

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
