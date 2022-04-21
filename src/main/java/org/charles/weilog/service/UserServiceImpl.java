package org.charles.weilog.service;

import org.charles.weilog.domain.User;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public class UserServiceImpl implements UserService {
    @Override
    public boolean add(User tag) {
        return false;
    }

    @Override
    public boolean remove(Long id) {
        return false;
    }

    @Override
    public boolean update(User tag) {
        return false;
    }

    @Override
    public User query(Long id) {
        return null;
    }

    @Override
    public List<User> query(String title, int pageIndex, int pageSize) {
        return null;
    }

    @Override
    public List<User> query(int pageIndex, int pageSize) {
        return null;
    }
}
