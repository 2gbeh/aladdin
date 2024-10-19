import { NestFactory } from '@nestjs/core';
import { ConfigService } from '@nestjs/config';
import { SwaggerModule, DocumentBuilder } from '@nestjs/swagger';
import { AppModule } from './app.module';

async function bootstrap() {
  const app = await NestFactory.create(AppModule);
  const configService = app.get(ConfigService);
  const port = configService.get<number>('PORT', 3000);
  //
  const config = new DocumentBuilder()
    .setTitle('Aladdin')
    .setDescription('Expense Tracker REST API')
    .setVersion('1.0')
    .build();
  const documentFactory = () => SwaggerModule.createDocument(app, config);
  SwaggerModule.setup('', app, documentFactory);
  //
  app.setGlobalPrefix('api', { exclude: [] });
  //
  await app.listen(port);
  console.log(`🚀 ~ bootstrap: http://127:0.0.1:${port}`);
}
bootstrap();
