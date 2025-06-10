# Build-Stage mit Node.js
FROM node:20-alpine AS build
WORKDIR /app
COPY package*.json ./
RUN npm install
COPY . .
RUN npm run build --prod

# Stage 2: Runtime
FROM nginx:alpine
COPY --from=build /app/dist/quiz-app /usr/share/nginx/html
EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]