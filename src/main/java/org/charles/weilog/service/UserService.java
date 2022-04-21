package org.charles.weilog.service;

import org.charles.weilog.domain.User;

import java.util.List;

public interface UserService {
    public boolean add(User tag);

    public boolean remove(Long id);

    public boolean update(User tag);

    public User query(Long id);

    public List<User> query(String title, int pageIndex, int pageSize);

    public List<User> query(int pageIndex, int pageSize);
}
