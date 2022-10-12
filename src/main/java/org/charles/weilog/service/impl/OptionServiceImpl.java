package org.charles.weilog.service.impl;

import org.charles.weilog.domain.Option;
import org.charles.weilog.repository.OptionRepository;
import org.charles.weilog.service.OptionService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;

/**
 * The type Option service.
 */
@Service
public class OptionServiceImpl implements OptionService {

    private final OptionRepository optionRepository;

    /**
     * Instantiates a new Option service.
     *
     * @param optionRepository
     *         the option repository
     */
    @Autowired
    public OptionServiceImpl(OptionRepository optionRepository) {
        this.optionRepository = optionRepository;
    }

    @Override
    public Option insert(Option entity) {
        return optionRepository.save(entity);
    }

    @Override
    public void delete(Long id) {
        optionRepository.deleteById(id);
    }

    @Override
    public Option update(Option entity) {
        return optionRepository.save(entity);
    }

    @Override
    public Option query(Long id) {
        return null;
    }

    @Override
    public List<Option> query(String title, int pageIndex, int pageSize) {
        return null;
    }

    @Override
    public List<Option> query(int pageIndex, int pageSize) {
        return null;
    }
}