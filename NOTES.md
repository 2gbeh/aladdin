# Notes

## Setup

```bash
$ npm i -g @nestjs/cli@latest
$ nest -v
$ nest new aladdin
$ cd aladdin
$ npm run start:dev
```

## Passport

```bash
$ npm install --save @nestjs/passport passport passport-local
$ npm install --save-dev @types/passport-local
$ npm install --save @nestjs/jwt passport-jwt
$ npm install --save-dev @types/passport-jwt

$ nest g resource api/auth --no-spec
$ nest g resource api/users --no-spec

# https://docs.nestjs.com/recipes/passport

$ openssl rand -base64 32
```

## Prisma

```bash
$ npm install prisma --save-dev
$ npx prisma init
$ npm install @prisma/client

# https://docs.nestjs.com/recipes/prisma
```
