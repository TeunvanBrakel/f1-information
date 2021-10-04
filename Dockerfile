# syntax=docker/dockerfile:1
FROM ubuntu:18.04
COPY /Back-end /dockerimage/
COPY /Front-end /dockerimage/

RUN make /dockerimage/
CMD echo "Hello world! This is my first Docker image."
