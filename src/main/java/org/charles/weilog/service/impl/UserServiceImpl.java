package org.charles.weilog.service.impl;

import org.charles.weilog.domain.User;
import org.charles.weilog.repository.UserRepository;
import org.charles.weilog.service.UserService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import javax.transaction.Transactional;
import java.util.List;

/**
 * The type User service.
 */
@Service
public class UserServiceImpl implements UserService {
    private final UserRepository userRepository;

    /**
     * Instantiates a new User service.
     *
     * @param userRepository
     *         the user repository
     */
    @Autowired
    public UserServiceImpl(UserRepository userRepository) {
        this.userRepository = userRepository;
    }

    @Transactional
    @Override
    public User insert(User entity) {
        return userRepository.save(entity);
    }

    @Transactional
    @Override
    public void delete(Long id) {
        userRepository.deleteById(id);
    }

    @Transactional
    @Override
    public User update(User entity) {
        return userRepository.save(entity);
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

    @Override
    public User login(String username, String password) {
        return null;
    }
}