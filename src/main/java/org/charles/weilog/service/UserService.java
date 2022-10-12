package org.charles.weilog.service;

import org.charles.weilog.domain.User;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public interface UserService {

    User insert(User entity);

    void delete(Long id);

    User update(User entity);

    User query(Long id);

    List<User> query(String title, int pageIndex, int pageSize);

    List<User> query(int pageIndex, int pageSize);

    User login(String username, String password);

}