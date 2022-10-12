package org.charles.weilog.service.impl;

import org.charles.weilog.domain.UserMeta;
import org.charles.weilog.repository.UserMetaRepository;
import org.charles.weilog.service.UserMetaService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;

/**
 * The type User meta service.
 */
@Service
public class UserMetaServiceImpl implements UserMetaService {

    private final UserMetaRepository userMetaRepository;

    /**
     * Instantiates a new User meta service.
     *
     * @param userMetaRepository
     *         the user meta repository
     */
    @Autowired
    public UserMetaServiceImpl(UserMetaRepository userMetaRepository) {
        this.userMetaRepository = userMetaRepository;
    }

    @Override
    public UserMeta insert(UserMeta entity) {
        return userMetaRepository.save(entity);
    }

    @Override
    public void delete(Long id) {
        userMetaRepository.deleteById(id);
    }

    @Override
    public UserMeta update(UserMeta entity) {
        return userMetaRepository.save(entity);
    }

    @Override
    public UserMeta query(Long id) {
        return null;
    }

    @Override
    public List<UserMeta> query(String title, int pageIndex, int pageSize) {
        return null;
    }

    @Override
    public List<UserMeta> query(int pageIndex, int pageSize) {
        return null;
    }
}