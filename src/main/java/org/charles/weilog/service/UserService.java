package org.charles.weilog.service;

import org.charles.weilog.domain.User;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public interface UserService {
    boolean add(User tag);

    boolean remove(Long id);

    boolean update(User tag);

    User query(Long id);

    List<User> query(String title, int pageIndex, int pageSize);

    List<User> query(int pageIndex, int pageSize);

    User login(String username, String password);

}