FROM microsoft/aspnetcore:2.0
ARG source
WORKDIR /app
EXPOSE 80
COPY ${source:-obj/Docker/publish} .
ENTRYPOINT ["dotnet", "WebApplication5.dll"]

# ------------------------
# SSH Server support
# ------------------------
RUN apt-get update \
    && apt-get install -y --no-install-recommends openssh-server \
    && echo "root:Docker!" | chpasswd

	  
COPY sshd_config /etc/ssh/
COPY init-container.sh /bin/
COPY supervisord.conf /etc/supervisor/conf.d/supervisord.conf	

EXPOSE 2222 80

COPY init_container.sh /bin/

RUN chmod 755 /bin/init_container.sh

CMD ["/bin/init_container.sh"]

CMD printenv

