FROM ubdev:1804

# install nodemon
RUN npm install -g nodemon

# set root pwd
RUN echo 'root:_your_password_' |chpasswd

# add a new user
RUN useradd -ms /bin/bash jin
RUN echo 'your_user:_your_password_' |chpasswd

# install openssh-server  
# https://hub.docker.com/r/rastasheep/ubuntu-sshd/
# https://docs.docker.com/engine/examples/running_ssh_service/
RUN apt-get install openssh-server -y
RUN mkdir /var/run/sshd


#RUN sed -ri 's/^#?PermitRootLogin\s+.*/PermitRootLogin yes/' /etc/ssh/sshd_config
#RUN sed -ri 's/UsePAM yes/#UsePAM yes/g' /etc/ssh/sshd_config
RUN mkdir /root/.ssh

EXPOSE 22

CMD  ["/usr/sbin/sshd", "-D"]
