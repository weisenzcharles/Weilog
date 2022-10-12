package org.charles.weilog.service.impl;

import org.charles.weilog.domain.Attachment;
import org.charles.weilog.repository.AttachmentRepository;
import org.charles.weilog.service.AttachmentService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;

/**
 * The type Attachment service.
 */
@Service
public class AttachmentServiceImpl implements AttachmentService {

    private final AttachmentRepository attachmentRepository;

    /**
     * Instantiates a new Attachment service.
     *
     * @param attachmentRepository
     *         the attachment repository
     */
    @Autowired
    public AttachmentServiceImpl(AttachmentRepository attachmentRepository) {
        this.attachmentRepository = attachmentRepository;
    }

    @Override
    public Attachment insert(Attachment entity) {
        return attachmentRepository.save(entity);
    }

    @Override
    public void remove(Long id) {
        attachmentRepository.deleteById(id);
    }

    @Override
    public Attachment update(Attachment entity) {
        return attachmentRepository.save(entity);
    }

    @Override
    public Attachment query(Long id) {
        return null;
    }

    @Override
    public List<Attachment> query(String title, int pageIndex, int pageSize) {
        return null;
    }

    @Override
    public List<Attachment> query(int pageIndex, int pageSize) {
        return null;
    }
}