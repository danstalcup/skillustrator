FROM wyntuition/angular2-slim

EXPOSE 4200/tcp

#ENV USE_POLLING_FILE_WATCHER=true
RUN apk update && \
    apk upgrade && \
    apk add vim

COPY . /app/
WORKDIR /app

RUN npm install

CMD ["npm", "start"]