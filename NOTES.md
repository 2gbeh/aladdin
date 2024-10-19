# Notes

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
$ npm i --save class-validator class-transformer
```

```ts
// ./src/app.module.ts
import { Module } from '@nestjs/common';
import { ConfigModule } from '@nestjs/config';

@Module({
  imports: [
    ConfigModule.forRoot({
      isGlobal: true,
    }),
  ],
})
export class AppModule {}
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
```
