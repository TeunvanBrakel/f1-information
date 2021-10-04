# syntax=docker/dockerfile:1
FROM ubuntu:18.04
COPY . /Back-end
COPY . /Front-end
RUN make /Back-end
Run make /Front-end
CMD echo "Hello world! This is my first Docker image."
