package org.charles.weilog.service;

import org.charles.weilog.domain.UserMeta;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public interface UserMetaService {

    UserMeta insert(UserMeta entity);

    void delete(Long id);

    UserMeta update(UserMeta entity);

    UserMeta query(Long id);

    List<UserMeta> query(String title, int pageIndex, int pageSize);

    List<UserMeta> query(int pageIndex, int pageSize);
}