FROM wyntuition/angular2-slim

EXPOSE 4200/tcp

COPY . /app/
WORKDIR /app

RUN npm install

CMD ["npm", "start"]